# Z80.NET #


## What is this? ##

Z80.NET is a Z80 processor simulator that can be used as the core component for developing computer emulators, or to exercise pieces of Z80 code in custom test code. It is written in C# targetting the .NET Framework 4 Client Profile.  

*NOTE: If you are reading this from the overview page of the project site in BitBucket, the links to documentation and code will not work. Please go and open [the README file itself in the root of the source code](https://bitbucket.org/konamiman/z80dotnet/src/develop/README.md) instead. Thanks!* 

## Hello, world! ##

```
#!csharp
var z80 = new Z80Processor();
z80.AutoStopOnRetWithStackEmpty = true;

var program = new byte[] {
    0x3E, 0x07, //LD A,7
    0xC6, 0x04, //ADD A,4
    0x3C,       //INC A
    0xC9        //RET
};
z80.Memory.SetContents(0, program);

z80.Start();

Debug.Assert(z80.Registers.A == 12);
Debug.Assert(z80.TStatesElapsedSinceStart == 28);
```

## How to use

1. Create an instance of [the Z80Processor class](Main/Z80Processor.cs).
2. Optionally, plug your own implementations of one or more of the [dependencies](Docs/Dependencies.md).
3. [Configure your instance](Docs/Configuration.md) as appropriate.
4. Optionally, capture [the memory access events](Docs/MemoryAccessFlow.md) and/or [the instruction execution events](Docs/InstructionExecutionFlow.md).
5. [Start the simulated processor execution](Docs/HowExecutionWorks.md) by using one of the execution control methods.
6. Execution will stop (and the execution method invoked will then return) when one of [the execution stop conditions is met](Docs/StopConditions.md). You can then check [the processor state](Docs/State.md) and, if desired, resume execution.   

Execution is completely synchronous: one single thread is used for everything, including firing events. As seen in the Hello World example, you just invoke one of the starting methods and wait until it returns (there are means to force this to happen, see [the execution stop conditions](Docs/StopConditions.md)). If you want some kind of multithreading, you'll have to implement it by yourself, I just tried to keep things simple. :-)

Interaction of the processor with the hosting code and the outside world (memory and ports) can be achieved by handling the class events, by plugging custom implementations of the dependencies, or both at the same time.

## Done & to do

This is a work in progress project. So far that's what is done:

* [The Z80Processor class](Main/Z80Processor.cs) and all of its [dependencies](Docs/Dependencies.md).
* [The infrastructure for executing instructions](Main/Instructions%20Execution/Core) and part of [the instructions themselves](Main/Instructions%20Execution/Instructions). All the single byte instructions and those prefixed with 0xED are implemented by now.
* [A good bunch of unit tests](Main.Tests).

...and that's what's left to do:

* The rest of the instructions
* The interrupts mechanism
* The code could probably benefit from some optimizations for speed

## Resources

The following resources have been used to develop this project:

* [Z80 official user manual](http://www.zilog.com/manage_directlink.php?filepath=docs/z80/um0080)
* [The undocumented Z80 documented](http://www.myquest.nl/z80undocumented/) by Sean Young.
* [Z80 instructions table](http://clrhome.org/table/) at [ClrHome.org](http://clrhome.org)
* [Z80 technical reference](http://www.worldofspectrum.org/faq/reference/z80reference.htm) at [WorldOfSpectrum.org](http://www.worldofspectrum.org)
* [Complete Z80 instruction set](http://www.ticalc.org/archives/files/fileinfo/195/19571.html) from [ticalc.org](http://www.ticalc.org). The [instruction tables in the code](Main/Instructions%20Execution/Core) were automatically generated from a modified version of this file. 

## Last but not least...

...if you like this project **[please consider donating!](http://www.konamiman.com#donate)** My kids need moar shoes!

## But who am I? ##

I'm [Konamiman, the MSX freak](http://www.konamiman.com). No more, no less.
