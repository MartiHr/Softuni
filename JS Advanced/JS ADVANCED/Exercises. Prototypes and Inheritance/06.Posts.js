function solution() {
    class Post{
        constructor(title, content){
            this.title = title;
            this.content = content;
        }
        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString() + `\nRating: ${this.likes - this.dislikes}`;

            let comments = '';
            if (this.comments.length > 0) {
                comments += '\nComments:'
                this.comments.forEach(x => comments += `\n * ${x}`);
            }
            result += comments;

            return result;
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view(){
            this.views++;
            return this; 
        }

        toString(){
            return super.toString() + `\nViews: ${this.views}`;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}