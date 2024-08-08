using System;
using System.Collections.Generic;

namespace Continuum.Core.Entities
{
    public class Page
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string PageName { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string BackgroundImage { get; set; }
        public Client Client { get; set; }
    }
}