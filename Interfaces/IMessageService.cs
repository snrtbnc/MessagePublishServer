using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMessageService
    {
        Task PublishtoAll(string message);

        Task PublishtoGroup(string groupId, string message);

        Task PublishtoPersonal(string personalId, string groupId, string message);
    }
}
