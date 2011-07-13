using System;
using System.Linq;
using Core.Commands;
using Core.Domain;
using EmailMaker.Commands.Messages;
using EmailMaker.Domain.Emails;

namespace EmailMaker.Commands.Handlers
{
    public class EnqueueEmailToBeSentCommandHandler : BaseCommandHandler<EnqueueEmailToBeSentCommand>
    {
        private readonly IRepository<Email> _emailRepository;

        public EnqueueEmailToBeSentCommandHandler(IRepository<Email> emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public override void Execute(EnqueueEmailToBeSentCommand command)
        {
            var email = _emailRepository.GetById(command.EmailId);
            throw new System.NotImplementedException();
            //var recipients = command.RecipientsStr.Split(new[]{","}, StringSplitOptions.RemoveEmptyEntries).Select(addr => addr.Trim());
            email.EnqueueEmailToBeSent(command.FromAddress, null, command.Subject);
        }
    }
}