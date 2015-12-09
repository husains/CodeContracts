// CodeContracts
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#define CONTRACTS_FULL

using System;
using System.Diagnostics.Contracts;
using Microsoft.Research.ClousotRegression;

namespace SymbolicTimeoutTest
{
    public class SymbolicTimeout
    {
        [ClousotRegressionTest]
        [RegressionOutcome(Outcome = ProofOutcome.Bottom, Message = @"This array access is unreached", PrimaryILOffset = 25, MethodILOffset = 0)]
        [RegressionOutcome(Outcome = ProofOutcome.Bottom, Message = @"This array access is unreached", PrimaryILOffset = 28, MethodILOffset = 0)]
        private void Test0(int N, int[] K)
        {
            Contract.Requires(K.Length == N);

            int b, j, t;
            b = N;
            while (b >= 1)
            {
                j = 1;
                t = 0;
                while (j <= b - 1)
                {
                    if (K[j - 1] > K[j])
                    {
                        // exchange j and j + 1; no side effects
                        t = j;
                    }
                    j++;
                }
                if (t == 0) return;
                b = t;
            }
        }
    }
}
