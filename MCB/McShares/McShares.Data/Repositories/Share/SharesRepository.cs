using AutoMapper;
using McShares.Core.ViewModels.Shares;
using McShares.Data.Contexts;
using McShares.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace McShares.Data.Repositories.Share
{
    public class SharesRepository : ISharesRepository
    {
        #region Declare Variables
        private readonly McSharesDbContext _McSharesDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SharesRepository(McSharesDbContext context, IMapper mapper)
        {
            _McSharesDbContext = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<DocumentCustomerSharesStaging>> SaveCustomerFromXml(string xml)
        {
            if (_McSharesDbContext != null)
            {
                SqlParameter xmlData = new SqlParameter("@xmlData", SqlDbType.Xml)
                {
                    Value = new SqlXml(XmlReader.Create(new StringReader(xml)))
                };
                //SqlParameter message = new SqlParameter("@message", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};

                // await _McSharesDbContext.Database.ExecuteSqlRawAsync("EXEC InsertShareDetailsFromXML @xmlData ", xmlData);

                return await _McSharesDbContext.DocumentCustomerSharesStaging.FromSqlRaw<DocumentCustomerSharesStaging>("EXEC InsertShareDetailsFromXML @xmlData ", xmlData).ToListAsync();
            }
            return null;
        }

        public async Task<List<Customer>> GetAllRecords(string contactname)
        {
            if (_McSharesDbContext != null)
            {
                SqlParameter[] sqlParColl = new SqlParameter[1];
                sqlParColl[0] = new SqlParameter("@ContactName", contactname);

                //SqlParameter contact = new SqlParameter("@ContactName", string.IsNullOrEmpty(contactname) ? string.Empty : contactname);
               
                return await _McSharesDbContext.Customer.FromSqlRaw<Customer>("EXEC GetCustomerList @ContactName ", sqlParColl).ToListAsync();
            }
            return null;
        }

        public async Task<string> UpdateRecord(AllDetailsViewModel customer)
        {
            if (_McSharesDbContext != null)
            {
                SqlParameter[] sqlParColl = new SqlParameter[11];
                sqlParColl[0] = new SqlParameter("@CustomerNo", customer.CustomerNo);
                //sqlParColl[1] = new SqlParameter("@DateOfBirth", customer.DateOfBirth);
                //sqlParColl[2] = new SqlParameter("@DateInCorporate", customer.DateInCorporate);
                sqlParColl[1] = new SqlParameter("@RegistrationNo", customer.RegistrationNo);
                sqlParColl[2] = new SqlParameter("@ContactName", customer.ContactName);
                sqlParColl[3] = new SqlParameter("@ContactNumber", customer.ContactNumber);
                sqlParColl[4] = new SqlParameter("@AddressLine1", customer.AddressLine1);
                sqlParColl[5] = new SqlParameter("@AdressLine2", customer.AdressLine2);
                sqlParColl[6] = new SqlParameter("@TownCity", customer.TownCity);
                sqlParColl[7] = new SqlParameter("@Country", customer.Country);
                sqlParColl[8] = new SqlParameter("@Shares", customer.Shares);
                sqlParColl[9] = new SqlParameter("@SharePrice", customer.Price);
                sqlParColl[10] = new SqlParameter("@message", "");
                sqlParColl[10].Direction = ParameterDirection.Output;
                sqlParColl[10].Size = 500;

                await _McSharesDbContext.Database.ExecuteSqlRawAsync("EXEC UpdateShareDetails @CustomerNo,@RegistrationNo,@ContactName,@ContactNumber,@AddressLine1,@AdressLine2,@TownCity,@Country,@Shares,@SharePrice,@message OUT",
                   sqlParColl);

                return Convert.ToString(sqlParColl[10].Value);
            }
            return null;
        }
        #endregion
    }
}
