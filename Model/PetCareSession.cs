using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Care_Web_API.Model
{
    //Pet care session details
    public class PetCareSession
    {
          public int Id { get; set; }

          public string PetName { get; set; }

          public string PetType { get; set; }

          public DateTime Start { get; set; }

          public DateTime End { get; set; }
    }
}
