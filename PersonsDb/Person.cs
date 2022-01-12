using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsDb
{
    public partial class Person
    {
        public long Id { get; set; }

        [RegularExpression(RegexProvider.firstname,
            ErrorMessage = "Firstname has to begin with capital letter and has to be at least 3 chars long")]
        public string? Firstname { get; set; }

        [RegularExpression(RegexProvider.lastname,
            ErrorMessage = "Lehner, DelPiro")]
        public string? Lastname { get; set; }

        [RegularExpression(RegexProvider.date,
            ErrorMessage = "Format: 01.02.2005")]
        public string Born { get; set; } = null!;

        [RegularExpression(RegexProvider.tel,
            ErrorMessage = "Format: +43 (10) 1234")]
        public string? Tel { get; set; }
        public long AdressId { get; set; }

        public virtual Adress Adress { get; set; } = null!;
    }
}
