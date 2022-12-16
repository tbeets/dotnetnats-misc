# dotnet-create-stream

Demonstrate issue in v2.9.9 (fixed in v2.9.10) where two streams could be made to subscribe to the same subject.

This was a validation bug specific to a non-clustered JS environment and the Update Stream API.
