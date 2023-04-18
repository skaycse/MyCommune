namespace MyCommune.Models
{
    public class ServiceResponse
	{
		private string _errorMessage;

		public StatusType Status { get; set; }

		public Exception Error { get; set; }

		public string ErrorMessage
		{
			get
			{
				if (string.IsNullOrEmpty(_errorMessage) && (Error != null))
				{
					if (!string.IsNullOrEmpty(Error.Message))
					{
						return Error.Message;
					}

					return Error.GetBaseException().GetType().Name;
				}

				return _errorMessage;
			}
			set { _errorMessage = value; }
		}
	}
	public class ServiceResponse<T> : ServiceResponse
	{
		/// <summary>
		/// Creates a new <see cref="ServiceResponse{T}"/> with the base non-generic fields cloned from the given other.
		/// </summary>
		/// <param name="otherBase"></param>
		public ServiceResponse(ServiceResponse otherBase)
			: base()
		{
			Status = otherBase.Status;
			Error = otherBase.Error;
			ErrorMessage = otherBase.ErrorMessage;
		}

		public ServiceResponse() : base() { }

		public T Data { get; set; }
	}
	public enum StatusType
	{
		Failure = 0,
		Success = 1
	}	
}