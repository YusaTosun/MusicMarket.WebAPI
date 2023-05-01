namespace MusicMarket.Services.DTO
{
    public class MusicDTO //todo:Bi dahakine tüm DTO'lara ayrı klasör açmak daha makul olacaktır
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistDTO Artist { get; set; }
    }
}
