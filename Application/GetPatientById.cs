using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class ListById
    {

        static readonly HttpClient client = new HttpClient();

        public class Query : IRequest<PatientsDTO>
        {
            public string PatientId { get; set; }
        }

        public class Handler : IRequestHandler<Query, PatientsDTO>
        {

            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<PatientsDTO> Handle(Query request, CancellationToken cancellationToken)
            {

                using HttpResponseMessage response = await client.GetAsync("https://ti-patient-service.azurewebsites.net/patients");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Patients> item = JsonConvert.DeserializeObject<List<Patients>>(responseBody);
                var decodeUrl = System.Uri.UnescapeDataString(request.PatientId);
                var decryptedGuid = EncryptionHelper.Decrypt(decodeUrl);
                var patient =  (from i in item
                                where i.PatientId == Guid.Parse(decryptedGuid)
                                select new PatientsDTO
                                
                                {
                                    PatientId = EncryptionHelper.Encrypt(i.PatientId.ToString()),
                                    FirstName = i.FirstName,
                                    LastName = i.LastName,
                                    Gender = i.Gender,
                                    DateOfBirth = i.DateOfBirth,
                                    AddressLine1 = i.AddressLine1,
                                    AddressLine2 = i.AddressLine2,
                                    City = i.City,
                                    PostalCode = i.PostalCode,
                                    State = i.State

                                }).FirstOrDefault();
                return patient ;
            }

        }
    }
}



