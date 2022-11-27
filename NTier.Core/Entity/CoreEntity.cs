using NTier.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        public CoreEntity()
        {
            Status = Status.Active;
            CreateDate = DateTime.Now;
            CreatedUserName = WindowsIdentity.GetCurrent().Name;
            CreatedComputerName = Environment.MachineName;
            CreatedIp = "123";
            CreatedBy = 1;
        }
        public Guid Id { get ; set; }
        public Guid? MasterId { get; set; }
        public Status Status { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedUserName { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedUserName { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
