using System;
using System.Collections.Generic;

namespace Continuum.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientName { get; set; }
        public string Logo { get; set; }
        public User User { get; set; }
        public Configuration Configuration { get; set; }
        public ICollection<ContentBlock> ContentBlocks { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<MediaContent> MediaContents { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
    }
}