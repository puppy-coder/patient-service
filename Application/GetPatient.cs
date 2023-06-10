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
    public class List
    {

        static readonly HttpClient client = new HttpClient();
        public class Query : IRequest<List<PatientsDTO>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<PatientsDTO>>
        {
            
            private readonly IMediator _mediator;

            public Handler( IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<List<PatientsDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                using HttpResponseMessage response = await client.GetAsync("https://ti-patient-service.azurewebsites.net/patients");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Patients> item = JsonConvert.DeserializeObject<List<Patients>>(responseBody);
                  var result =  (from i in item 
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

                                }).ToList();
                return result;
            }
        

        
                   
            }
        }
    }




