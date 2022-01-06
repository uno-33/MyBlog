export class Blog {
  id: number;
  name: string;
  creatorId: string;
  creatorName: string;

  constructor(id: number, name: string, creatorId: string, creatorName: string) {
    this.id = id;
    this.name = name;
    this.creatorId = creatorId;
    this.creatorName = creatorName;
  }
}