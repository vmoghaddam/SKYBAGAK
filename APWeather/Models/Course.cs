using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APWeather.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseAircraftType = new HashSet<CourseAircraftType>();
            CourseCatRate = new HashSet<CourseCatRate>();
            CoursePeople = new HashSet<CoursePeople>();
            CourseRelatedAircraftType = new HashSet<CourseRelatedAircraftType>();
            CourseRelatedCourseCourse = new HashSet<CourseRelatedCourse>();
            CourseRelatedCourseRelatedCourse = new HashSet<CourseRelatedCourse>();
            CourseRelatedCourseType = new HashSet<CourseRelatedCourseType>();
            CourseRelatedEmployee = new HashSet<CourseRelatedEmployee>();
            CourseRelatedGroup = new HashSet<CourseRelatedGroup>();
            CourseRelatedStudyField = new HashSet<CourseRelatedStudyField>();
            CourseSession = new HashSet<CourseSession>();
            CourseSessionFDP = new HashSet<CourseSessionFDP>();
            CourseSessionPresence = new HashSet<CourseSessionPresence>();
            CourseSessionPresenceDetail = new HashSet<CourseSessionPresenceDetail>();
            PersonCourse = new HashSet<PersonCourse>();
        }

        public int Id { get; set; }
        public int CourseTypeId { get; set; }
        public DateTime DateStart { get; set; }
        public decimal? DateStartP { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? DateEndP { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int? OrganizationId { get; set; }
        public int? Duration { get; set; }
        public int? DurationUnitId { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? Capacity { get; set; }
        public int? Tuition { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? DateDeadlineRegistration { get; set; }
        public decimal? DateDeadlineRegistrationP { get; set; }
        public string TrainingDirector { get; set; }
        public string Title { get; set; }
        public int? AircraftTypeId { get; set; }
        public int? AircraftModelId { get; set; }
        public int? CaoTypeId { get; set; }
        public bool? Recurrent { get; set; }
        public int? Interval { get; set; }
        public int? CalanderTypeId { get; set; }
        public bool? IsInside { get; set; }
        public bool? Quarantine { get; set; }
        public DateTime? DateStartPractical { get; set; }
        public DateTime? DateEndPractical { get; set; }
        public decimal? DateStartPracticalP { get; set; }
        public decimal? DateEndPracticalP { get; set; }
        public int? DurationPractical { get; set; }
        public int? DurationPracticalUnitId { get; set; }
        public bool? IsGeneral { get; set; }
        public int? CustomerId { get; set; }
        public string No { get; set; }
        public bool? IsNotificationEnabled { get; set; }

        public virtual AircraftModel AircraftModel { get; set; }
        public virtual AircraftType AircraftType { get; set; }
        public virtual CaoType CaoType { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual Teacher Currency { get; set; }
        public virtual ICollection<CourseAircraftType> CourseAircraftType { get; set; }
        public virtual ICollection<CourseCatRate> CourseCatRate { get; set; }
        public virtual ICollection<CoursePeople> CoursePeople { get; set; }
        public virtual ICollection<CourseRelatedAircraftType> CourseRelatedAircraftType { get; set; }
        public virtual ICollection<CourseRelatedCourse> CourseRelatedCourseCourse { get; set; }
        public virtual ICollection<CourseRelatedCourse> CourseRelatedCourseRelatedCourse { get; set; }
        public virtual ICollection<CourseRelatedCourseType> CourseRelatedCourseType { get; set; }
        public virtual ICollection<CourseRelatedEmployee> CourseRelatedEmployee { get; set; }
        public virtual ICollection<CourseRelatedGroup> CourseRelatedGroup { get; set; }
        public virtual ICollection<CourseRelatedStudyField> CourseRelatedStudyField { get; set; }
        public virtual ICollection<CourseSession> CourseSession { get; set; }
        public virtual ICollection<CourseSessionFDP> CourseSessionFDP { get; set; }
        public virtual ICollection<CourseSessionPresence> CourseSessionPresence { get; set; }
        public virtual ICollection<CourseSessionPresenceDetail> CourseSessionPresenceDetail { get; set; }
        public virtual ICollection<PersonCourse> PersonCourse { get; set; }
    }
}
