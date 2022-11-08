## Introduction

Small application to initiate C# discussions during a job interview, with a
[Reverse Code Review][reverse-code-review] as starting point.

I did an example review myself here on our internal [gitlab][gitlab].

# The code

The code in this repo is a small application that does a request to some
web service to query employee information and create a few types of reports
from the data.

Some notes about the code you'll find here:
- It compiles but doesn't work because the infrastructure parts are not
  implemented. This doesn't matter for discussing the parts that are there.
- The code is intentionally written in a way to invite discussions.


[gitlab]: https://git.tss.cloud/common/csharpinterview/-/merge_requests/2
[reverse-code-review]: https://jacobian.org/2021/dec/15/wst-reverse-review/
