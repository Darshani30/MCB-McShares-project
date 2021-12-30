using McShares.API.Services.File;
using McShares.Core.Constant;
using McShares.Core.ViewModels.Shares;
using McShares.Services.Shares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace McShares.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SharesController : ControllerBase
    {
        #region Declare Variables
        private readonly IFileService _fileService;
        private readonly IShareService _shareService;
        private IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public SharesController(IFileService fileService, IHostingEnvironment hostingEnvironment, IShareService shareService)
        {
            _fileService = fileService;
            _hostingEnvironment = hostingEnvironment;
            _shareService = shareService;
        }
        #endregion

        #region Methods  

        // POST api/upload
        [HttpPost(nameof(Upload))]
        public async Task<IActionResult> Upload([Required] IFormFile formFile)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(formFile.FileName) + DateTime.Now.ToString("yyyyMMddHHmmssfff")+ Path.GetExtension(formFile.FileName);
                await _fileService.UploadFile(formFile, Constants.SUB_DIRECTORY, fileName);

                string xmlString = System.IO.File.ReadAllText(Constants.SUB_DIRECTORY + "\\" + fileName);

                var result = await _shareService.SaveCustomerFromXml(xmlString);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/upload
        [HttpGet(nameof(GetAllRecords))]
        public async Task<IActionResult> GetAllRecords(string contactname)
        {
            try
            {
                var result = await _shareService.GetAllRecords(contactname);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/UpdateRecord
        [HttpPost(nameof(UpdateRecord))]
        public async Task<IActionResult> UpdateRecord(AllDetailsViewModel customer)
        {
            try
            {
                var result = await _shareService.UpdateRecord(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Download
        [HttpGet(nameof(Download))]
        public async Task<IActionResult> Download()
        {

            try
            {
                //get all feedback records
                var listCustomet = await _shareService.GetAllRecords("");

                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable customer = converter.ToDataTable(listCustomet);

                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = customer.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in customer.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field =>
                      string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    sb.AppendLine(string.Join(",", fields));
                }
                byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
                Response.Clear();
                Response.Headers.Add("content-disposition", "attachment;filename=Customer.csv");
                Response.ContentType = "text/csv";
                Response.Body.WriteAsync(byteArray);
                Response.Body.FlushAsync();

                return File(Response.Body, Response.ContentType, "Customer.csv");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }
        #endregion
    }
}
