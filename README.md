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

# Some general questions:

- Can you Explain SOLID principles
- Do you know what design patterns are, could you give an example?
- what does it mean that something is thread safe e.g some collection
- What is a lambda function and how would you use one

- what's the difference between a struct and a class? How does a record fit in?
- can you explain how to use async/await?
- why would you need a dispose method?
- what is polymorphism?
- why would you use `using` in C#
- give an example of scenario where using LINQ's SelectMany would be reasonable


[gitlab]: https://git.tss.cloud/common/csharpinterview/-/merge_requests/2
[reverse-code-review]: https://jacobian.org/2021/dec/15/wst-reverse-review/
