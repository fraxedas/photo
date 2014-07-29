namespace photo.exif
{
    public class ExifItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int Length { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} = {2}", Id, Title, Value);
        }
    }
}
