using DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Result
{
    public class ResultVM
    {
        public int ResultId { get; set; }
        public CharacterState ChearState { get; set; }
        public Character? AnotherCharacter { get; set; }
        public CharacterPositionResult? ChearPositionResult { get; set; }
        public int? PatientId { get; set; }
        public int? ChearId { get; set; }
    }
}
