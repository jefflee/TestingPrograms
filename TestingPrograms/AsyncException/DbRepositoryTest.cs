using FluentAssertions.Execution;

namespace TestingPrograms.AsyncException
{
    [TestFixture]
    internal class DbRepositoryTest
    {

        [Test]
        public void CallingWithResult_Exception_BothCheckCanBePassed()
        {
            var repository = new DbRepository();
            Action act = () => repository.CallingWithResult();
            using (new AssertionScope())
            {
                act.Should().Throw<AggregateException>()
                    .WithMessage("One or more errors occurred. (This is not implemented)");
                act.Should().Throw<NotImplementedException>().WithMessage("This is not implemented");
            }
        }

        [Test]
        public void CallingWithResult_Exception_TypeIsAggregateException()
        {
            var repository = new DbRepository();
            try
            {
                repository.CallingWithResult();
            }
            catch (Exception ex)
            {
                // Assert
                // Exception type is AggregateException
                ex.GetType().Should().Be<AggregateException>();
                ex.GetType().Should().NotBe<NotImplementedException>();
                ex.Message.Should().Be("One or more errors occurred. (This is not implemented)");

                // Inner Exception type is NotImplementedException
                Exception innerEx = ex!.InnerException;
                innerEx!.GetType().Should().Be<NotImplementedException>();
                innerEx.Message.Should().Be("This is not implemented");
            }
        }

        [Test]
        public void CallingWithAwait_Exception_TypeIsNotImplementedException()
        {
            var repository = new DbRepository();
            Func<Task> func = async () => await repository.CallingWithAwait();
            func.Should().ThrowAsync<NotImplementedException>().WithMessage("* NOT IMPLEMENTED");
        }

        [Test]
        public void CallingWithWaitAndUnwrapException_Exception_TypeIsNotImplementedException()
        {
            var repository = new DbRepository();
            try
            {
                repository.CallingWithWaitAndUnwrapException();
            }
            catch (Exception ex)
            {
                // Assert
                ex.GetType().Should().Be<NotImplementedException>();
                ex.GetType().Should().NotBe<AggregateException>();
                ex.Message.Should().Be("This is not implemented");
            }
        }

        [Test]
        public void CallingWithAsyncContext_Exception_TypeIsNotImplementedException()
        {
            var repository = new DbRepository();
            try
            {
                repository.CallingWithAsyncContext();
            }
            catch (Exception ex)
            {
                // Assert
                ex.GetType().Should().Be<NotImplementedException>();
                ex.GetType().Should().NotBe<AggregateException>();
                ex.Message.Should().Be("This is not implemented");
            }
        }

        [Test]
        public void CallingWithTaskAndNitoAsyncEx_Exception_TypeIsNotImplementedException()
        {
            var repository = new DbRepository();
            try
            {
                repository.CallingWithTaskAndNitoAsyncEx();
            }
            catch (Exception ex)
            {
                // Assert
                ex.GetType().Should().Be<NotImplementedException>();
                ex.GetType().Should().NotBe<AggregateException>();
                ex.Message.Should().Be("This is not implemented");
            }
        }

        [Test]
        public void CallingWithTask_Exception_TypeIsNotImplementedException()
        {
            var repository = new DbRepository();
            try
            {
                repository.CallingWithTask();
            }
            catch (Exception ex)
            {
                // Assert
                ex.GetType().Should().Be<AggregateException>();
                ex.GetType().Should().NotBe<NotImplementedException>();
                ex.Message.Should().Be("One or more errors occurred. (This is not implemented)");
            }
        }
    }
}
