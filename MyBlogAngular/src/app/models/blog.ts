export class Blog {
  id: number;
  name: string;
  description: string;
  creatorId: string;
  creatorName: string;

  constructor(id: number, 
    name: string, 
    description: string, 
    creatorId: string, 
    creatorName: string) {
      
    this.id = id;
    this.name = name;
    this.description = description;
    this.creatorId = creatorId;
    this.creatorName = creatorName;
  }
}