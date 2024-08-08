using System;

namespace Continuum.Core.Entities
{
    public class MediaContent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public Client Client { get; set; }
    }
}