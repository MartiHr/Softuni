import { useState, useEffect } from 'react';

import * as userService from '../../services/userService';

import { Pagination } from "./pagination/Pagination";
import { UserDetails } from './user-details/UserDetails';
import { UserDelete } from './user-delete/UserDelete';
import { UserItem } from './user-item/UserItem';
import { UserActions } from './UserListConstants';
import { UserCreate } from './user-create/UserCreate';
import { UserEdit } from './user-edit/UserEdit';

export const UserList = () => {

    const [users, setUsers] = useState([]);
    const [userAction, setUserAction] = useState({ user: null, action: null });

    useEffect(() => {
        userService.getAll()
            .then(users => setUsers(users));
    }, [users]);

    const userActionClickHandler = (userId, actionType) => {
        userService.getOne(userId)
            .then(user => {
                setUserAction({
                    user,
                    action: actionType
                });
            });
    }

    const closeHandler = () => {
        setUserAction({ user: null, action: null })
    }

    const createHandler = (e) => {
        e.preventDefault();

        debugger

        const formData = new FormData(e.target);

        const {
            firstName,
            lastName,
            email,
            imageUrl,
            phoneNumber,
            ...address
        } = Object.fromEntries(formData);

        const userData = {
            firstName,
            lastName,
            email,
            imageUrl,
            phoneNumber,
            address,
        };

        userService.createOne(userData);
        closeHandler();
    }

    const updateHandler = (e, userId) => {
        e.preventDefault();

        const formData = new FormData(e.target);

        const {
            firstName,
            lastName,
            email,
            imageUrl,
            phoneNumber,
            ...address
        } = Object.fromEntries(formData);

        const userData = {
            firstName,
            lastName,
            email,
            imageUrl,
            phoneNumber,
            address,
        };

        userService.updateOne(userId, userData);
        closeHandler();
    }

    const deleteHandler = (userId) => {
        userService.deleteOne(userId);
        closeHandler();
    }

    return (
        <>
            {userAction.action === UserActions.Create &&
                <UserCreate
                    onCreate={createHandler}
                    onClose={closeHandler}
                />
            }

            {userAction.action === UserActions.Details &&
                <UserDetails
                    user={userAction.user}
                    onClose={closeHandler}
                />
            }

            {userAction.action === UserActions.Edit &&
                <UserEdit
                    user={userAction.user}
                    onEdit={updateHandler}
                    onClose={closeHandler}
                />
            }

            {userAction.action === UserActions.Delete &&
                <UserDelete
                    userId={userAction.user._id}
                    onClose={closeHandler}
                    onDelete={deleteHandler}
                />
            }

            <div className="table-wrapper">
                <table className="table">
                    <thead>
                        <tr>
                            <th>
                                Image
                            </th>
                            <th>
                                First name<svg className="icon" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path fill="currentColor" d="M374.6 310.6l-160 160C208.4 476.9 200.2 480 192 480s-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 370.8V64c0-17.69 14.33-31.1 31.1-31.1S224 46.31 224 64v306.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0S387.1 298.1 374.6 310.6z">
                                    </path>
                                </svg>
                            </th>
                            <th>
                                Last name<svg className="icon" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path fill="currentColor" d="M374.6 310.6l-160 160C208.4 476.9 200.2 480 192 480s-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 370.8V64c0-17.69 14.33-31.1 31.1-31.1S224 46.31 224 64v306.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0S387.1 298.1 374.6 310.6z">
                                    </path>
                                </svg>
                            </th>
                            <th>
                                Email<svg className="icon" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path fill="currentColor" d="M374.6 310.6l-160 160C208.4 476.9 200.2 480 192 480s-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 370.8V64c0-17.69 14.33-31.1 31.1-31.1S224 46.31 224 64v306.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0S387.1 298.1 374.6 310.6z">
                                    </path>
                                </svg>
                            </th>
                            <th>
                                Phone<svg className="icon" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path fill="currentColor" d="M374.6 310.6l-160 160C208.4 476.9 200.2 480 192 480s-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 370.8V64c0-17.69 14.33-31.1 31.1-31.1S224 46.31 224 64v306.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0S387.1 298.1 374.6 310.6z">
                                    </path>
                                </svg>
                            </th>
                            <th>
                                Created
                                <svg className="icon active-icon" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-down" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512">
                                    <path fill="currentColor" d="M374.6 310.6l-160 160C208.4 476.9 200.2 480 192 480s-16.38-3.125-22.62-9.375l-160-160c-12.5-12.5-12.5-32.75 0-45.25s32.75-12.5 45.25 0L160 370.8V64c0-17.69 14.33-31.1 31.1-31.1S224 46.31 224 64v306.8l105.4-105.4c12.5-12.5 32.75-12.5 45.25 0S387.1 298.1 374.6 310.6z">
                                    </path>
                                </svg>
                            </th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user =>
                            <tr key={user._id}>
                                <UserItem
                                    user={user}
                                    onActionClick={userActionClickHandler}
                                />
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>

            {/* New user button  */}
            <button className="btn-add btn" onClick={() => userActionClickHandler(null, UserActions.Create)}>Add new user</button>

            <Pagination />
        </>
    );
}

{/* Overlap components  */ }
{/* <div class="loading-shade"> */ }
{/* Loading spinner  */ }
{/* <div class="spinner"></div> */ }
{/* No users added yet  */ }
{/* <div class="table-overlap">
    <svg
        aria-hidden="true"
        focusable="false"
        data-prefix="fas"
        data-icon="triangle-exclamation"
        class="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
        role="img"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 512 512"
    >
        <path
            fill="currentColor"
            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
        ></path>
    </svg>
    <h2>There is no users yet.</h2>
</div> */}
{/* No content overlap component  */ }
{/* <div class="table-overlap">
    <svg
        aria-hidden="true"
        focusable="false"
        data-prefix="fas"
        data-icon="triangle-exclamation"
        class="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
        role="img"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 512 512"
    >
        <path
            fill="currentColor"
            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
        ></path>
    </svg>
    <h2>Sorry, we couldn't find what you're looking for.</h2>
</div> */}
{/* On error overlap component  */ }

{/* <div class="table-overlap">
    <svg
        aria-hidden="true"
        focusable="false"
        data-prefix="fas"
        data-icon="triangle-exclamation"
        class="svg-inline--fa fa-triangle-exclamation Table_icon__+HHgn"
        role="img"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 512 512"
    >
        <path
            fill="currentColor"
            d="M506.3 417l-213.3-364c-16.33-28-57.54-28-73.98 0l-213.2 364C-10.59 444.9 9.849 480 42.74 480h426.6C502.1 480 522.6 445 506.3 417zM232 168c0-13.25 10.75-24 24-24S280 154.8 280 168v128c0 13.25-10.75 24-23.1 24S232 309.3 232 296V168zM256 416c-17.36 0-31.44-14.08-31.44-31.44c0-17.36 14.07-31.44 31.44-31.44s31.44 14.08 31.44 31.44C287.4 401.9 273.4 416 256 416z"
        ></path>
    </svg>
    <h2>Failed to fetch</h2>
</div> */}
{/* </div> */ }