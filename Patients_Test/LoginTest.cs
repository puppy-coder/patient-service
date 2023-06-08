using MediatR;
using FluentAssertions;

namespace Patients_Test;

public class LoginTest
{

    private readonly Application.Login.Handler _handler;
    private readonly IMediator _mediator;
    public LoginTest()
    {
        //Arrange

        _handler = new Application.Login.Handler();
       
    }
    [Fact]
    public void LoginTest_ResponseNotNull()
    {
        Application.Login.Command command = new Application.Login.Command()
        {
            Email = "test@gmail.com",
            Password = "password"
        };

        CancellationToken token = new CancellationToken();
        var testMethod = _handler.Handle(command, token);
        //Assert
        testMethod.Should().NotBeNull();

    }
}