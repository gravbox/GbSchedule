using System;
using System.Collections;

namespace Objects
{

	[Serializable()]
	public class ADACodeCollection : CollectionBase
	{

		//Property Member Variables

		public ADACode this[int index] 
		{
			get {return ((ADACode)(List[index])); }
			set { List[index] = value; }
		}
        
		public ADACode this[string key]
		{
			get 
			{
				foreach (ADACode element in this)
				{
					if (element.ID.Equals(key))
						return element;

				}
				throw new Exception("Object not found!");
			}
		}

		public int Add(string key) 
		{
			return Add(key, "", -1);
		}

		public int Add(string key, string text) 
		{
			return Add(key, text, -1);
		}

		public int Add(string key, string text, int index) 
		{

			if (key != "")
			{
				//Error check that the new key does not exist
				if (Contains(key))
				{
					throw new Exception(ErrorStringDuplicateKeyCollection);
				}
				newObject.SetKey(key);
			} 
			else
			{
				key = newObject.Key;
			}

			newObject.Text = text;

			//Error Check
			key = Trim(key);
			if (key == "")
				throw new Exception(ErrorStringNoKey);
			else if (Contains(key))
				throw new Exception(ErrorStringDuplicateKeyCollection);      

			try
			{
				//Create the object and add it to the collections
				newObject.SetKey(key);
				return AddObject(newObject, index);
			}
			catch(Exception ex)
			{
				Globals.SetErr(ex);
			}

		}

		public ADACodeItem AddObject(ADACodeItem newObject)
		{
			return AddObject(newObject, -1);
		}

		public ADACodeItem AddObject(ADACodeItem newObject, int index)
		{

			//The object must be set and it must NOT have a parent
			if (newObject == null) 
				return null;

			if (newObject.Parent != null)
				throw new Exception(ErrorStringObjectHasParent);
      

			if ((index < -1) || (index > Me.Count))
			{
				//Subscript out of range
				throw new System.ArgumentOutOfRangeException();
			}

			if (newObject.Key == "")
				newObject.Key = System.Guid.NewGuid().ToString;

			try
			{
				if (index = -1)
					MyBase.List.Add(newObject);
				else
					MyBase.List.Insert(index, newObject);
			}
			catch (Exception ex)
			{
				Globals.SetErr(ex);
			}

			newObject.SetParent(this);

			return newObject;

		}

		public bool SetIndex(ADACode element, int newIndex)
		{
			int index = this.IndexOf(element);
			if (index == -1) return false;

			base.RemoveAt(index);
			base.List.Insert(newIndex, element);
			return true;			
		}

		public int IndexOf(ADACode value)
		{
			return base.List.IndexOf(value);
		}

		public int IndexOf(string key)
		{
			int ii = -1;
			foreach (ADACode element in this)
			{
				ii++;
				if (element.ID.Equals(key))
					return ii;

			}
			return ii;
		}

		public bool Contains(ADACode value) 
		{
			return base.List.Contains(value);
		}

		public bool Contains(string key) 
		{
			foreach (ADACode element in this)
				if (element.Key.ToLower().Equals(key.ToLower())) 
					return true;

			foreach (ADACode element in this)
				if (element.Text.ToLower().Equals(key.ToLower())) 
					return true;

			return false;
		}
        
		public bool Contains(int index) 
		{
			return ((0 <= index) && (index < this.Count));
		}

		public bool Contains(ADACodeItem element) 
		{
			foreach (ADACode element in this)
				if (element == element) 
					return true;

			return false;
		}

		public new ADACodeEnumerator GetEnumerator() 
		{
			return new ADACodeEnumerator(this);
		}
        
		public new bool RemoveAt(int index)
		{
			List.RemoveAt(index);
			return true;
		}
        
		public bool Remove(ADACode value)
		{
			List.Remove(value);
			return true;
		}
        
		public class ADACodeEnumerator : object, IEnumerator 
		{
            
			private IEnumerator baseEnumerator;            
			private IEnumerable temp;
			public ADACodeEnumerator(ADACodeCollection mappings) 
			{
				this.temp = ((IEnumerable)(mappings));
				this.baseEnumerator = temp.GetEnumerator();
			}
            
			public ADACode Current 
			{
				get { return ((ADACode)(baseEnumerator.Current)); }
			}
            
			object IEnumerator.Current 
			{
				get { return baseEnumerator.Current; }
			}
            
			public bool MoveNext() 
			{
				return baseEnumerator.MoveNext();
			}
            
			bool IEnumerator.MoveNext() 
			{
				return baseEnumerator.MoveNext();
			}
            
			public void Reset() 
			{
				baseEnumerator.Reset();
			}
            
			void IEnumerator.Reset() 
			{
				baseEnumerator.Reset();
			}
		}


	}

}
