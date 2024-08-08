using System;

namespace Continuum.Core.Entities
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Platform { get; set; }
        public string Username { get; set; }
        public string Followers { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public Client Client { get; set; }
    }
}