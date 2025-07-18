﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbiquoDotNet.FluentApi.Abstractions;

namespace UbiquoDotNet.FluentApi
{
    internal record StubDto
    {
        public required string Name { get; set; }
        public required string Host { get; set; }
        public required IRequest Request { get; set; }

        //[JsonProperty("response")]
        public required IResponse Response { get; set; }
    }
}
