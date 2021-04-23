﻿using System.Collections.Generic;

namespace FootballInfoApp.API.Infrastructure.Models
{
     public class RequestFilters
     {
          public RequestFilters()
          {
               Filters = new List<Filter>();
          }

          public FilterLogicalOperators LogicalOperator { get; set; }

          public IList<Filter> Filters { get; set; }
     }
}
