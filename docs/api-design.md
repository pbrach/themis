# Themis Web API
**NOTE:** `~` is used in this document as abbreviation to www.themis.com or any other domain name under which the web app will be hosted.

The API consists of two controllers:

- Home (Landing Page, About, Feedback, Contact, Impress, etc.)
- Plan (Creating, Editing and Showing Plans)

Moreover there will be two variants of that API:
- one for an MVC-razor-views client
- one for a react client

The MVC client can be reached under `~/`, while the react client (its static content) can be reached under `~/spa`. The react client will use mostly similar routes as the MVC client, but with a preceeding `/api` (e.g.: `www.themis/api/plan/asxwefr55v6e32$&$%`).


## Ideas and Concepts
### Privacy and Authorization via Hash-URIs
We try to implement a simple login free privacy and authorization concept. Thus created plans will be unencrypted reachable by URL *but* via a specific **access-id** (`{id}`). That ID allows so many combinations that finding a plan by chance is significantly smaller than 1%. They could look like this: `asxwefr55v6e32$&$%`.  
For editing a plan we want to use a second similar ID in the URL as an authorization token. The so called: **authorization-id** will be created in the same way like the normal IDs, but adding it to the access-id in the URL it gives a user the power to UPDATE and DELETE a plan. The authorization-id should only be shared with admin users of the plan.

### Implications of the ID-URIs
1. We use `plan` instead of the 100% RESTful correct plural `plans` for the plan controller, because users should not be able to view multiple plans. Their view should always be restricted to one plan at a time and there will not be a list of plans.

2. The home page won't allow to navigate to the SHOW of a specific plan. It only provides a link to `~/plan/create`. The SHOW action can only be reached via direct link that the original creator of the plan will receive. He must share it with every plan participant.

## API Description (MVC)
| Route | Verb | Function |
|-------|------|----------|
| `~/`                       | GET         | Home Page|
| `~/plan/create`            | GET         | SHOW the plan-create form |
| `~/plan`                   | POST        | CREATEs a new plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `~/plan/success`. |
| `~/plan/success`           | GET         | SHOWs the two urls to the plan (one with `acc-hash` and one with `authhash`) |
| `~/plan/{id}`              | GET         | SHOWs the read-only plan. Might allow queries/filtering in future |
| `~/plan/{id}?token={token}`| GET         | SHOWs EDIT form for the plan. |
| `~/plan/{id}?token={token}`| PUT         | UPDATEs the plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `GET:~/plan/<{id}>`. |
| `~/plan/{id}?token={token}`| DELETE      | DELETEs the plan. Data must be provided as Json in the request body. On submit success, the client is redirected to `GET:~/`. |


## API Description (SPA)

| Route | Verb | Function |
|-------|------|----------|
| `~/api/plan`                    | AJAX~POST   | Same as MVC variant, but on submit success the two hashes are returned as server response to this method. |
| `~/api/plan/{id}`               | AJAX~GET    | GETs the read-only data for a plan as Json |
| `~/api/plan/{id}?token={token}` | AJAX~PUT    | UPDATEs the plan. Data must be provided as Json in the request body. |
| `~/api/plan/{id}?token={token}` | AJAX~DELETE | DELETEs the plan. Data must be provided as Json in the request body. |

## TO-DO: Data Description 
