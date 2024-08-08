using System;

namespace Continuum.Core.Entities
{
    public class Configuration
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string HeaderTitle { get; set; }
        public string HeaderSubtitle { get; set; }
        public string HeaderBackgroundImage { get; set; }
        public string FooterText { get; set; }
        public Client Client { get; set; }
    }
}