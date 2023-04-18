using eTickets.Data.Enums;
using eTickets.Models;
using static System.Net.WebRequestMethods;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "cinema 1",
                            Logo = "https://th.bing.com/th/id/OIP.-_6COeVAJh8eT9S2dfKTFwHaHa?w=178&h=180&c=7&r=0&o=5&pid=1.7",
                            Description = "This is the desc"
                        },
                        new Cinema()
                        {
                            Name = "cinema 2",
                            Logo = "https://studentcard.mes.gov.ge/misc/topic/gallery/1459833970.png",
                            Description = "This is the desc"
                        }
                    });
                    context.SaveChanges();
                }
                //actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Fullname = "actor 1",
                            Bio = "this is bio",
                            ProfilePictureURL = "https://www.bing.com/images/search?view=detailV2&ccid=Mj8FlFoe&id=728CDAA377F0A21B88C931F394DB43BDBB65C2F9&thid=OIP.Mj8FlFoeJWWYlDNXBO6bFQHaLH&mediaurl=https%3a%2f%2fi.pinimg.com%2foriginals%2ffc%2f2b%2f9e%2ffc2b9ebf40aeaa493228f4fe66d8456d.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.323f05945a1e25659894335704ee9b15%3frik%3d%252bcJlu71D25TzMQ%26pid%3dImgRaw%26r%3d0&exph=3000&expw=2000&q=angelina+white&simid=608030480406561164&FORM=IRPRST&ck=00887AE6A436F3E8E68B6971F90A6A25&selectedIndex=12"
                        },
                        new Actor()
                        {
                            Fullname = "actor 2",
                            Bio = "this is bio",
                            ProfilePictureURL = "https://www.bing.com/images/search?view=detailV2&ccid=vEvu4EhS&id=53AB17B29CC216BB669E9FC1DA905030119DC09C&thid=OIP.vEvu4EhSib1L3qHQTn6SKQHaKR&mediaurl=https%3a%2f%2fcelebmafia.com%2fwp-content%2fuploads%2f2018%2f06%2fsasha-grey-kicks-off-inaugural-stereo-hyde-with-electrifying-dj-set-in-las-vegas-5.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.bc4beee0485289bd4bdea1d04e7e9229%3frik%3dnMCdETBQkNrBnw%26pid%3dImgRaw%26r%3d0&exph=1776&expw=1280&q=sasha+grey&simid=607993526499827230&FORM=IRPRST&ck=4B6E305BE14102F3EDC253C4ED21F208&selectedIndex=0"
                        }
                    });
                    context.SaveChanges();
                }
                //producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Fullname = "producer 1",
                            Bio = "this is bio",
                            ProfilePictureURL = "https://www.bing.com/images/search?view=detailV2&ccid=dDhPB2iC&id=E5F9B3A35062B375CD666F1C6E440B446F97F793&thid=OIP.dDhPB2iCtvAv9vB0c5Sy7QAAAA&mediaurl=https%3a%2f%2fsupport.musicgateway.com%2fwp-content%2fuploads%2f2020%2f12%2fCopy-of-800-x-500-Blog-Post-1-4.png&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.74384f076882b6f02ff6f0747394b2ed%3frik%3dk%252feXb0QLRG4cbw%26pid%3dImgRaw%26r%3d0&exph=296&expw=474&q=top++film+producers&simid=608024480331927224&FORM=IRPRST&ck=B030161C55947449113A74C3A562A66C&selectedIndex=0"
                        }, 
                        new Producer()
                        {
                            Fullname = "producer 2",
                            Bio = "this is bio",
                            ProfilePictureURL = "https://www.bing.com/images/search?view=detailV2&ccid=Js2YDj8T&id=3148ED30C5C785E90851EE33803F4AA83C3B2FA6&thid=OIP.Js2YDj8TGRGCBwESl-VEKwHaD8&mediaurl=https%3a%2f%2fwww.trendrr.net%2fwp-content%2fuploads%2f2017%2f07%2fPeter-Jackson.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.26cd980e3f1319118207011297e5442b%3frik%3dpi87PKhKP4Az7g%26pid%3dImgRaw%26r%3d0&exph=465&expw=872&q=top++film+producers&simid=607999058415784428&FORM=IRPRST&ck=C6BE78B3D24B2CDC9FF519F6D72DAAA5&selectedIndex=2"
                        }
                    });
                    context.SaveChanges();
                }
                //movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "scoob",
                            Description = "This is the scoob movie description",
                            Price = 39.50,
                            ImageUrl = "https://th.bing.com/th/id/R.8de71284a3ca7aa6f7ba5e26bfb9bfcf?rik=r9j3aJVYt8Rsaw&pid=ImgRaw&r=0",
                            StratDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Comedy

                        }, 
                        new Movie()
                        {
                            Name = "cold soles",
                            Description = "This is the scoob movie description",
                            Price = 39.50,
                            ImageUrl = "https://th.bing.com/th/id/OIP.M8_HvT-Rt8TrEvx9_EsaKwHaKe?pid=ImgDet&rs=1",
                            StratDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Comedy
                        }
                    });
                    context.SaveChanges();
                }
                //actors & movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
