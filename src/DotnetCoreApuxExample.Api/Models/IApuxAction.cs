using System;
using Newtonsoft.Json;

namespace DotnetCoreApuxExample.Api.Models
{
    public interface IApuxAction<T>
    {
        string Type { get; set; }

        T Payload { get; set; }
    }
}