﻿using System;
using System.Diagnostics;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Konamiman.Z80dotNet.Tests
{
    public class Z80ProcessorTests
    {
        Z80Processor Sut { get; set; }
        Fixture Fixture { get; set; }

        [SetUp]
        public void Setup()
        {
            Fixture = new Fixture();

            Sut = new Z80Processor();
        }

        [Test]
        public void Can_create_instances()
        {
            Assert.IsNotNull(Sut);
        }

        [Test]
        public void Has_proper_defaults()
        {
            Assert.AreEqual(4, Sut.ClockFrequencyInMHz);
            Assert.AreEqual(1, Sut.ClockSpeedFactor);

            Assert.IsFalse(Sut.AutoStopOnDiPlusHalt);
            Assert.IsFalse(Sut.AutoStopOnRetWithStackEmpty);

            Assert.IsInstanceOf<PlainMemory>(Sut.Memory);
            Assert.AreEqual(65536, Sut.Memory.Size);
            Assert.IsInstanceOf<PlainMemory>(Sut.PortsSpace);
            Assert.AreEqual(256, Sut.PortsSpace.Size);

            for(int i = 0; i < 65536; i++) {
                Assert.AreEqual(MemoryAccessMode.ReadAndWrite, Sut.GetMemoryAccessMode((ushort)i));
                Assert.AreEqual(0, Sut.GetMemoryWaitStatesForM1((ushort)i));
                Assert.AreEqual(0, Sut.GetMemoryWaitStatesForNonM1((ushort)i));
            }       
            for(int i = 0; i < 256; i++) {
                Assert.AreEqual(MemoryAccessMode.ReadAndWrite, Sut.GetPortAccessMode((byte) i));
                Assert.AreEqual(0, Sut.GetPortWaitStates((byte) i));
            }

            Assert.IsInstanceOf<Z80Registers>(Sut.Registers);
            Assert.IsInstanceOf<MainZ80Registers>(Sut.Registers.Main);
            Assert.IsInstanceOf<MainZ80Registers>(Sut.Registers.Alternate);

            Assert.IsInstanceOf<Z80InstructionExecutor>(Sut.InstructionExecutor);
            Assert.AreSame(Sut, Sut.InstructionExecutor.ProcessorAgent);
            Assert.IsInstanceOf<ClockSynchronizationHelper>(Sut.ClockSynchronizationHelper);

            Assert.AreEqual(StopReason.NeverRan, Sut.StopReason);
            Assert.AreEqual(ProcessorState.Stopped, Sut.State);
            Assert.IsFalse(Sut.IsHalted);
            Assert.IsNull(Sut.UserState);
        }

        [Test]
        [Ignore]
        public void HelloWorld()
        {
            Sut.AutoStopOnRetWithStackEmpty = true;

            var program = new byte[]
            {
                0x3E, 0x07, //LD A,7
                0xC6, 0x04, //ADD A,4
                0x3C,       //INC A
                0xC9        //RET
            };
            Sut.Memory.SetContents(0, program);

            Sut.Start();

            Assert.AreEqual(12, Sut.Registers.Main.A);
        }

        [Test]
        public void Reset_sets_registers_properly()
        {
            Sut.Registers.IFF1 = 1;
            Sut.Registers.IFF1 = 1;
            Sut.Registers.PC = 1;
            Sut.Registers.Main.AF = 0;
            Sut.Registers.SP = 0;
            Sut.InterruptMode = 1;

            Sut.Reset();

            Assert.AreEqual(0xFFFF.ToShort(), Sut.Registers.Main.AF);
            Assert.AreEqual(0xFFFF.ToShort(), Sut.Registers.SP);
            Assert.AreEqual(0, Sut.Registers.PC);
            Assert.AreEqual(0, Sut.Registers.IFF1);
            Assert.AreEqual(0, Sut.Registers.IFF2);
            Assert.AreEqual(0, Sut.InterruptMode);

            Assert.AreEqual(0, Sut.TStatesElapsedSinceReset);
        }

        [Test]
        public void Interrupt_mode_can_be_set_to_0_1_or_2()
        {
            Sut.InterruptMode = 0;
            Sut.InterruptMode = 1;
            Sut.InterruptMode = 2;
        }

        [Test]
        public void Interrupt_mode_cannot_be_set_to_higher_than_2()
        {
            Assert.Throws<ArgumentException>(() => Sut.InterruptMode = 3);
        }
    }
}