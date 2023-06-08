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
        public class Query : IRequest<List<Domain.Patients>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Domain.Patients>>
        {
            
            private readonly IMediator _mediator;
            private readonly IHostingEnvironment _hostingEnvironment;

            public Handler( IMediator mediator, IHostingEnvironment hostingEnvironment)
            {
               
                _mediator = mediator;
                _hostingEnvironment = hostingEnvironment;
            }

            public async Task<List<Domain.Patients>> Handle(Query request, CancellationToken cancellationToken)
            {
                   using (StreamReader r = new StreamReader("D:\\Patients_Project_Net_Core\\Domain\\Patients.json"))
            {
                string json = r.ReadToEnd();
                List<Patients> item = JsonConvert.DeserializeObject<List<Patients>>(json);
                  var result =  (from i in item 
                                select new Patients
                                {
                                    PatientId = Guid.Parse(string.Format("************{0}", i.PatientId.ToString()
                                    .Substring(12, 4))),
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
}



