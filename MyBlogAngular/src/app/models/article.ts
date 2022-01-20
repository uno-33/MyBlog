/*public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int BlogId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }*/

export class Article {
  id : number;
  title: string;
  content: string;
  dateOfCreation: Date;
  blogId: number;
  creatorId: string;
  creatorName: string;

  /**
   *
   */
  constructor(id : number,
    title: string,
    content: string,
    dateOfCreation: Date,
    blogId: number,
    creatorId: string,
    creatorName: string) {

    this.id = id;
    this.title = title;
    this.content = content;
    this.dateOfCreation = dateOfCreation;
    this.blogId = blogId;
    this.creatorId = creatorId;
    this.creatorName = creatorName;
  }
}