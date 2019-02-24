namespace CucbanquyenModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public int questionId { get; set; }

        [Required(ErrorMessage ="Trường yêu cầu bắt buộc!")]
        [StringLength(256)]
        public string questionTitle { get; set; }

        [Required(ErrorMessage ="Trường yêu cầu bắt buộc!")]
        [StringLength(256)]
        public string fullName { get; set; }

        [StringLength(512)]
        public string address { get; set; }

        [StringLength(256)]
        [Required(ErrorMessage = "Trường yêu cầu bắt buộc!")]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public bool isTrash { get; set; }

        public int languageId { get; set; }

        public DateTime createTime { get; set; }

        [StringLength(2048)]
        public string questionBody { get; set; }

        [StringLength(128)]
        public string attachment { get; set; }

        public virtual IEnumerable<Answer> Answers { set; get; }
    }

    [Table("Answer")]
    public partial class Answer
    {
        public int answerId { get; set; }

        public int questionId { get; set; }

        public int languageId { get; set; }

        public string questionBody { get; set; }

        [StringLength(256)]
        public string userName { get; set; }

        public bool isTrash { get; set; }

        public DateTime createTime { get; set; }

        public virtual Question Question { set; get; }
    }

    public class QuestionView
    {
        public int Total { set; get; }
        public IEnumerable<Question> Questions { set; get; }
    }

    public class AnswerView
    {
        public int Total { set; get; }
        public IEnumerable<Answer> Answers { set; get; }
    }
}
