using MalcoCorporateFramawork.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MalcoCorporateAPIBusinessRules.Errors
{
    public class ErrorCatched
    {
        private readonly string InternalErrorCode = null;
        private readonly string InternalErrorkind = null;
        private readonly string Description = null;
        private readonly string PossibleSolution = null;

        public ErrorCatched(string internalErrorCode, string internalErrorkind, string description, string possibleSolution)
        {
            InternalErrorCode = internalErrorCode;
            InternalErrorkind = internalErrorkind;
            Description = description;
            PossibleSolution = possibleSolution;
        }

        public string GetJson()
        {
            return GenericFunctions.ConvertToJson(this);
        }

        public override string ToString()
        {
            return "InternalErrorCode: " + this.InternalErrorCode + Environment.NewLine +
                   "InternalErrorkind: " + this.InternalErrorCode + Environment.NewLine +
                   "Description: " + this.InternalErrorCode + Environment.NewLine +
                   "PossibleSolution: " + this.InternalErrorCode + Environment.NewLine;
        }

    }
}
