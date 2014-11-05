using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms.Calendar
{
    /// <summary>
    /// Contains basic information about a drawing event for <see cref="CalendarRenderer"/>
    /// </summary>
    public class CalendarRendererEventArgs
        : EventArgs
    {
        #region Events

        #endregion

        #region Fields
        private Calendar _calendar;
        private Rectangle _clip;
        private Graphics _graphics;
        private object _tag;
        #endregion

        #region Ctor

        /// <summary>
        /// Use it wisely just to initialize some stuff
        /// </summary>
        protected CalendarRendererEventArgs()
        {

        }

        /// <summary>
        /// Creates a new <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="calendar">Calendar where painting</param>
        /// <param name="g">Device where to paint</param>
        /// <param name="clip">Paint event clip area</param>
        public CalendarRendererEventArgs(Calendar calendar, Graphics g, Rectangle clipRectangle)
        {
            _calendar = calendar;
            _graphics = g;
            _clip = clipRectangle;
        }

        /// <summary>
        /// Creates a new <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="calendar">Calendar where painting</param>
        /// <param name="g">Device where to paint</param>
        /// <param name="clip">Paint event clip area</param>
        public CalendarRendererEventArgs(Calendar calendar, Graphics g, Rectangle clipRectangle, object tag)
        {
            _calendar = calendar;
            _graphics = g;
            _clip = clipRectangle;
            _tag = tag;
        }

        /// <summary>
        /// Copies the parameters from the specified <see cref="CalendarRendererEventArgs"/>
        /// </summary>
        /// <param name="original"></param>
        public CalendarRendererEventArgs(CalendarRendererEventArgs original)
        {
            _calendar = original.Calendar;
            _graphics = original.Graphics;
            _clip = original.ClipRectangle;
            _tag = original.Tag;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the calendar where painting
        /// </summary>
        public Calendar Calendar
        {
            get { return _calendar; }
        }

        /// <summary>
        /// Gets the clip of the paint event
        /// </summary>
        public Rectangle ClipRectangle
        {
            get { return _clip; }
        }

        /// <summary>
        /// Gets the device where to paint
        /// </summary>
        public Graphics Graphics
        {
            get { return _graphics; }
        }

        /// <summary>
        /// Gets or sets a tag for the event
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
