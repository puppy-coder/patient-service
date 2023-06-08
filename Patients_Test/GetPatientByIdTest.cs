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
    public class GetPatientByIdTest
    {
        private readonly Application.ListById.Handler _handler;
        private readonly IMediator _mediator;
        public GetPatientByIdTest()
        {
            //Arrange

            _handler = new Application.ListById.Handler(_mediator);

        }
        [Fact]
        public void GetPatientTest_ResponseNotNull()
        {
            Application.ListById.Query query = new Application.ListById.Query();


            CancellationToken token = new CancellationToken();
            var testMethod = _handler.Handle(query, token);
            //Assert
            testMethod.Should().NotBeNull();

        }
    }
}
