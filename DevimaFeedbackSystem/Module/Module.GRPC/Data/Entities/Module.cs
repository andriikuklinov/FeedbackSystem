using DevimaFeedbackSystem.Common.Core.DataAccess.Model;

namespace Module.GRPC.Data.Entities
{
    public class Module: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
