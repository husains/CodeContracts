// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Research.ClousotRegression;
using System.Diagnostics.Contracts;

public static class Test
{
    [ClousotRegressionTest]
    // no proof obligation as it isn't reachable in the CFG already
    public static int M(int x)
    {
        Contract.Ensures(false);

        throw new Exception();
    }
}
