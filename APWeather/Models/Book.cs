using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAutor = new HashSet<BookAutor>();
            BookChapter = new HashSet<BookChapter>();
            BookFile = new HashSet<BookFile>();
            BookKeyword = new HashSet<BookKeyword>();
            BookRelatedAircraftType = new HashSet<BookRelatedAircraftType>();
            BookRelatedEmployee = new HashSet<BookRelatedEmployee>();
            BookRelatedGroup = new HashSet<BookRelatedGroup>();
            BookRelatedStudyField = new HashSet<BookRelatedStudyField>();
            Chapter = new HashSet<Chapter>();
            EmployeeBookStatus = new HashSet<EmployeeBookStatus>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime? DateRelease { get; set; }
        public int? PublisherId { get; set; }
        public string ISSNPrint { get; set; }
        public string ISSNElectronic { get; set; }
        public string DOI { get; set; }
        public string Pages { get; set; }
        public int CategoryId { get; set; }
        public int? CustomerId { get; set; }
        public string Abstract { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DatePublished { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateDeadline { get; set; }
        public string Duration { get; set; }
        public int? LanguageId { get; set; }
        public string ExternalUrl { get; set; }
        public int? NumberOfLessens { get; set; }
        public int TypeId { get; set; }
        public int? JournalId { get; set; }
        public string Conference { get; set; }
        public int? ConferenceLocationId { get; set; }
        public string DateConference { get; set; }
        public string Sender { get; set; }
        public string No { get; set; }
        public string PublishedIn { get; set; }
        public string INSPECAccessionNumber { get; set; }
        public string Edition { get; set; }
        public string DateEffective { get; set; }
        public int? FolderId { get; set; }
        public int? Issue { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateValidUntil { get; set; }
        public string BookKey { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Organization Publisher { get; set; }
        public virtual ICollection<BookAutor> BookAutor { get; set; }
        public virtual ICollection<BookChapter> BookChapter { get; set; }
        public virtual ICollection<BookFile> BookFile { get; set; }
        public virtual ICollection<BookKeyword> BookKeyword { get; set; }
        public virtual ICollection<BookRelatedAircraftType> BookRelatedAircraftType { get; set; }
        public virtual ICollection<BookRelatedEmployee> BookRelatedEmployee { get; set; }
        public virtual ICollection<BookRelatedGroup> BookRelatedGroup { get; set; }
        public virtual ICollection<BookRelatedStudyField> BookRelatedStudyField { get; set; }
        public virtual ICollection<Chapter> Chapter { get; set; }
        public virtual ICollection<EmployeeBookStatus> EmployeeBookStatus { get; set; }
    }
}
