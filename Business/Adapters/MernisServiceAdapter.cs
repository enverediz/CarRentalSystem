using Core.Entities.Concrete;
using Entities.DTOs;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters
{
    public class MernisServiceAdapter : IPersonCheckService
    {
        public bool CheckIfRealPerson(User user)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
            return client.TCKimlikNoDogrulaAsync(Convert.ToInt64(user.NationalIdentity), user.FirstName.ToUpper(),
                user.LastName.ToUpper(), user.BirthDate.Year).Result.Body.TCKimlikNoDogrulaResult;

            
        }
    }
}
