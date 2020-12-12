﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class WorkItemComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Comment { get; set; }
        public string SubmittedBy { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime SubmittedOn { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Updated { get; set; }
        [ForeignKey("WorkItem")]
        public string CommentWorkItemID { get; set; }
        public WorkItem WorkItem { get; set; }

    }
}