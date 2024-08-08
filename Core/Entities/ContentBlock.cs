using System;

namespace Continuum.Core.Entities
{
    public class ContentBlock
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public Client Client { get; set; }
    }
}