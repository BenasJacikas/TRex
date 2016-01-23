﻿using Swashbuckle.Swagger;
using System.Collections.Generic;
using TRex.Metadata;

namespace QuickLearn.ApiApps.Metadata.Extensions
{
    internal static class ParameterExtensions
    {
        public static void EnsureVendorExtensions(this Parameter parameter)
        {
            if (parameter.vendorExtensions == null) parameter.vendorExtensions = new Dictionary<string, object>();
        }

        public static void SetSchedulerRecommendation(this Parameter parameter, string recommendation)
        {
            parameter.EnsureVendorExtensions();

            if (!parameter.vendorExtensions.ContainsKey(Constants.X_MS_SCHEDULER_RECOMMENDATION))
            {
                parameter.vendorExtensions.Add(Constants.X_MS_SCHEDULER_RECOMMENDATION, recommendation);
            }
        }

        public static void SetVisibility(this Parameter parameter, VisibilityType visibility)
        {
            if (visibility == VisibilityType.Default) return;

            parameter.EnsureVendorExtensions();

            if (!parameter.vendorExtensions.ContainsKey(Constants.X_MS_VISIBILITY))
            {
                parameter.vendorExtensions.Add(Constants.X_MS_VISIBILITY,
                    visibility.ToString().ToLowerInvariant());
            }
        }

        public static void SetFriendlyNameAndDescription(this Parameter parameter, string friendlyName, string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
                parameter.description = description;

            if (string.IsNullOrWhiteSpace(friendlyName)) return;

            parameter.EnsureVendorExtensions();

            if (!parameter.vendorExtensions.ContainsKey(Constants.X_MS_SUMMARY))
            {
                parameter.vendorExtensions.Add(Constants.X_MS_SUMMARY, friendlyName);
            }
        }

    }
}
