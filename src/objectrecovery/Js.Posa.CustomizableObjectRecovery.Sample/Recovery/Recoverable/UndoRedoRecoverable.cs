namespace Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.Recoverer;
    using Js.Posa.CustomizableObjectRecovery.Sample.Recovery.RecoveryPoint;

    /// <summary>
    /// Recovery interface base class for providing objects with an undo/redo mechanism.
    /// </summary>
    /// <typeparam name="T">The type of recoverable objects.</typeparam>
    public abstract class UndoRedoRecoverable<T>
        where T : ICloneable
    {
        private readonly Stack<RecoveryPoint<T>> pastRecoveryPoints;
        private readonly Stack<RecoveryPoint<T>> futureRecoveryPoints;
        private readonly Recoverer<T> recoverer;
        private readonly RecoveryPoint<T>.IFactory recoveryPointFactory;
        private T instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoRecoverable{T}"/> class.
        /// </summary>
        /// <param name="instance">The current instance.</param>
        public UndoRedoRecoverable(T instance)
        {
            this.pastRecoveryPoints = new Stack<RecoveryPoint<T>>();
            this.futureRecoveryPoints = new Stack<RecoveryPoint<T>>();
            this.recoverer = new UpdateInPlaceUndoRedoRecoverer<T>(instance);
            this.recoveryPointFactory = CopyRecoveryPoint<T>.Factory;

            this.instance = instance;
        }

        /// <summary>
        /// Gets the current underlying instance.
        /// </summary>
        protected T Instance
        {
            get { return this.instance; }
        }

        /// <summary>
        /// Undo an operation (goes back to most recent recovery point instance).
        /// </summary>
        public void Undo()
        {
            if (!this.pastRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.pastRecoveryPoints.Pop();
            this.instance = rp.Undo(this.instance);
            this.futureRecoveryPoints.Push(rp);
        }

        /// <summary>
        /// Redo an operation (go forward to previously undone recovery point instance).
        /// </summary>
        public void Redo()
        {
            if (!this.futureRecoveryPoints.Any())
            {
                throw new InvalidOperationException();
            }

            var rp = this.futureRecoveryPoints.Pop();
            this.instance = rp.Redo(this.instance);
            this.pastRecoveryPoints.Push(rp);
        }

        /// <summary>
        /// Prepares the recovery point.
        /// </summary>
        /// <returns>A recovery point.</returns>
        protected RecoveryPoint<T> PrepareRecoveryPoint()
        {
            var recoveryPoint = this.recoveryPointFactory.Prepare(this.instance);
            this.instance = this.recoverer.Prepare(recoveryPoint);
            return recoveryPoint;
        }

        /// <summary>
        /// Adds the recovery point to the undo command history.
        /// </summary>
        /// <param name="recoveryPoint">The recovery point to add.</param>
        protected void AddRecoveryPointToHistory(RecoveryPoint<T> recoveryPoint)
        {
            this.pastRecoveryPoints.Push(recoveryPoint);
        }
    }
}
