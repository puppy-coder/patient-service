using Domain;
using MediatR;


namespace Application
{
    public class Login
    {
        public class Command : IRequest<Domain.User>
        {
            public string Email{get;set;}
            public string Password{get;set;}
        }

        public class Handler : IRequestHandler<Command, Domain.User>
        {
            private List<User> users = new List<User>()
                   {
                        new User()
                        {
                            Email = "dhanakatheer@gmail.com",
                            Password = "Dhana@123"
                        },

                        new User()
                        {
                            Email = "pinky123@gmail.com",
                            Password = "Pinky@123"
                        }
                   };

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                 var user = users.Find(x => x.Email!.Equals(request.Email, StringComparison.InvariantCulture)
                             && x.Password == request.Password);  

                  return user;
                   
            }
        }
    }
}

        

        
                   
            
        
    




