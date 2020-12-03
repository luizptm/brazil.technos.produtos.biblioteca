using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{
    public class Application
    {
		public virtual string Name { get; set; }

		public virtual string SecretWord { get; set; }

		public virtual string SecretWordEncrypted { get; set; }

		public virtual int SecondsToExpire { get; set; }
	}
}
