using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patients_Test
{
    public class GetPatientTest
    {
        private readonly Application.List.Handler _handler;
        private readonly IMediator _mediator;
        private readonly IHostingEnvironment _hostingEnvironment;
        public GetPatientTest()
        {
            //Arrange

            _handler = new Application.List.Handler(_mediator, _hostingEnvironment);

        }
        [Fact]
        public void GetPatientTest_ResponseNotNull()
        {
            Application.List.Query query = new Application.List.Query();
           

            CancellationToken token = new CancellationToken();
            var testMethod = _handler.Handle(query, token);
            //Assert
            testMethod.Should().NotBeNull();

        }
    }
}
