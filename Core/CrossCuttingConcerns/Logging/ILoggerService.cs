using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILoggerService
    {
        void Write(String message);
    }
}
