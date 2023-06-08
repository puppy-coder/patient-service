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
        public class Query : IRequest<Domain.Patients>
        {
            public Guid PatientId{get;set;}
        }

        public class Handler : IRequestHandler<Query, Domain.Patients>
        {
            
            private readonly IMediator _mediator;

            public Handler( IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<Domain.Patients> Handle(Query request, CancellationToken cancellationToken)
            {
                   using (StreamReader r = new StreamReader("D:\\Patients_Project_Net_Core\\Domain\\Patients.json"))
            {
                string json = r.ReadToEnd();
                List<Patients> item = JsonConvert.DeserializeObject<List<Patients>>(json);
                var patient = item.Where(x => x.PatientId == request.PatientId).FirstOrDefault();
                return patient;
            }
        

        
                   
            }
        }
    }
}



