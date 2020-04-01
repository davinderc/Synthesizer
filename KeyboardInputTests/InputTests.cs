using Xunit;

namespace Synthesizer.Tests
{
    public class InputTests
    {
        private readonly string keyName;
        InputTests()
        {
            keyName = "A";
        }
        [Fact]
        public void KeyDownTest()
        {
            // throw some kind of key down event
            // check that key state is down
            Assert.Equal(keyEvent.State, keyDown);
            Assert.Equal(this.keyName, keyEvent.Name);
        }

        [Fact]
        public void KeyUpTest()
        {
            // throw some kind of key up event
            // check that key state is up
            Assert.Equal(keyEvent.State, keyUp);
            Assert.Equal(this.keyName, keyEvent.Name);
        }

        [Fact]
        public void TimeElapsedTest()
        {
            // KeyDown event
            // Start stopwatch
            // KeyUp event
            // grab stopwatch time
            // grab key pressed time
            // compare to stopwatch time

        }

        [Fact]
        public void MultipleKeysDownTest()
        {
            // KeyDown event for key "A"
            // KeyDown event for key "S"
            // assert that key "A" is down
            // assert that key "S" is down
        }

        [Fact]
        public void MultipleKeysDownSingleKeyReleasedTest()
        {
            // KeyDown event for key "A"
            // KeyDown event for key "S"
            // KeyUp event for key "A"
            // assert that key "A" is up
            // assert that key "S" is down
        }
    }
}
